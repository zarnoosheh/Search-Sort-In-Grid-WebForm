using GridSimple;
using GridSimple.Model;
using GridSimple.Services;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace GridSample
{
    public partial class Main : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Bind();
        }

        private void Bind()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["PageSize"]))
                drpPageSize.SelectedValue = Request.QueryString["PageSize"].ToString();

            using (PersonService _PersonService = new PersonService())
            {
                var xParameter = GetSearchParameters();
                int xListCount = 0;
                List<Person> xPersonList = _PersonService.GetPerson(ref xListCount, xParameter);
                lstPerson.DataSource = xPersonList;
                lstPerson.DataBind();
                ComPager._Count = xListCount;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string _SearchQuery = "";

            if (!string.IsNullOrWhiteSpace(txtFirstname.Text))
                _SearchQuery += string.Format("&Firstname={0}", txtFirstname.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                _SearchQuery += string.Format("&LastName={0}", txtLastName.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtNationalID.Text))
                _SearchQuery += string.Format("&NationalID={0}", txtNationalID.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtFatherName.Text))
                _SearchQuery += string.Format("&FatherName={0}", txtFatherName.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtBirthPlace.Text))
                _SearchQuery += string.Format("&BirthCartPlace={0}", txtBirthPlace.Text.Trim());

            if (drpSortBy.SelectedValue != "FirstName")
                _SearchQuery += string.Format("&SortBy={0}", drpSortBy.SelectedValue);

            if (drpSortType.SelectedValue != "Des")
                _SearchQuery += string.Format("&SortType={0}", drpSortType.SelectedValue);

            _SearchQuery = Request.Url.AbsolutePath + "?" + _SearchQuery.TrimStart('&');
            _SearchQuery = _SearchQuery.TrimEnd('?');
            Response.Redirect(_SearchQuery);
        }

        protected void drpPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            _URL.Redirect("PageSize", drpPageSize.SelectedValue, "Page");
        }

        public PersonSearchParameter GetSearchParameters()
        {
            PersonSearchParameter xParameters = new PersonSearchParameter();

            if (!string.IsNullOrWhiteSpace(Request.QueryString["FirstName"]))
            {
                xParameters.xFirstName = Request.QueryString["FirstName"].ToString();
                txtFirstname.Text = xParameters.xFirstName;
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["LastName"]))
            {
                xParameters.xLastName = Request.QueryString["LastName"].ToString();
                txtLastName.Text = xParameters.xLastName;
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["FatherName"]))
            {
                xParameters.xFatherName = Request.QueryString["FatherName"].ToString();
                txtFatherName.Text = xParameters.xFatherName;
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["NationalID"]))
            {
                xParameters.xNationalID = Request.QueryString["NationalID"].ToString();
                txtNationalID.Text = xParameters.xNationalID;
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["BirthCartPlace"]))
            {
                xParameters.xBirthCartPlace = Request.QueryString["BirthCartPlace"].ToString();
                txtBirthPlace.Text = xParameters.xBirthCartPlace;
            }

            xParameters.xSortBy = "FirstName";
            if (!string.IsNullOrWhiteSpace(Request.QueryString["SortBy"]))
            {
                xParameters.xSortBy = Request.QueryString["SortBy"];
                drpSortBy.SelectedValue = xParameters.xSortBy;
            }

            xParameters.xSortType = "Des";
            if (!string.IsNullOrWhiteSpace(Request.QueryString["SortType"]))
            {
                xParameters.xSortType = Request.QueryString["SortType"];
                drpSortType.SelectedValue = xParameters.xSortType;
            }

            xParameters.xPage = 1;
            xParameters.xPageSize = drpPageSize.SelectedValue == "All" ? int.MaxValue : drpPageSize.SelectedValue.ToInt();
            ComPager._PageSize = xParameters.xPageSize;
            ComPager._PagerSize = 10;
            if (Request.QueryString["Page"] != null)
                xParameters.xPage = Request.QueryString["Page"].ToInt();

            return xParameters;
        }
    }
}