# Search & Sort In Grid WebForm

Bind Data To Grid & Pager :

```C#
private void Bind()
{
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
```


Filter & Sort In Service by UnitOfWork:

```C#

public List<Person> GetPerson(ref int xCount, PersonSearchParameter xParameter)
{
    using (UnitOfWork uow = new UnitOfWork())
    {
        #region Clean xParameter
        xParameter.xFirstName = xParameter.xFirstName.Trim().ToLower();
        xParameter.xLastName = xParameter.xLastName.Trim().ToLower();
        xParameter.xFatherName = xParameter.xFatherName.Trim().ToLower();
        xParameter.xNationalID = xParameter.xNationalID.Trim().ToLower();
        xParameter.xBirthCartPlace = xParameter.xBirthCartPlace.Trim().ToLower();
        #endregion

        #region OrderBy
        Func<IQueryable<Person>, IOrderedQueryable<Person>> xOrderBy = p => p.OrderBy(x => x.xFirstName);
        if (xParameter.xSortBy == "FirstName" || string.IsNullOrEmpty(xParameter.xSortBy))
        {
            if (xParameter.xSortType == "Des")
            {
                xOrderBy = p => p.OrderByDescending(x => x.xFirstName);
            }
            else
            {
                xOrderBy = p => p.OrderBy(x => x.xFirstName);
            }
        }
        else if (xParameter.xSortBy == "LastName")
        {
            if (xParameter.xSortType == "Des")
            {
                xOrderBy = p => p.OrderByDescending(x => x.xLastName);
            }
            else
            {
                xOrderBy = p => p.OrderBy(x => x.xLastName);
            }
        }
        else if (xParameter.xSortBy == "FatherName")
        {
            if (xParameter.xSortType == "Des")
            {
                xOrderBy = p => p.OrderByDescending(x => x.xFatherName);
            }
            else
            {
                xOrderBy = p => p.OrderBy(x => x.xFatherName);
            }
        }
        #endregion

        #region Filter
        Expression<Func<Person, bool>> xFilter = p => true;

        if (!string.IsNullOrEmpty(xParameter.xFirstName))
            xFilter = xFilter.And(p => p.xFirstName.Contains(xParameter.xFirstName));

        if (!string.IsNullOrEmpty(xParameter.xLastName))
            xFilter = xFilter.And(p => p.xLastName.Contains(xParameter.xLastName));

        if (!string.IsNullOrEmpty(xParameter.xFatherName))
            xFilter = xFilter.And(p => p.xLastName.Contains(xParameter.xFatherName));

        if (!string.IsNullOrEmpty(xParameter.xNationalID))
            xFilter = xFilter.And(p => p.xNationalID.Contains(xParameter.xNationalID));

        if (!string.IsNullOrEmpty(xParameter.xBirthCartPlace))
            xFilter = xFilter.And(p => p.xBirthCartPlace.Contains(xParameter.xBirthCartPlace));
        #endregion

        var xPlanList = uow.PersonRepository.Get(ref xCount, xFilter, xOrderBy, xParameter.xPage, xParameter.xPageSize);
        return xPlanList.ToList();
    }
}
```
