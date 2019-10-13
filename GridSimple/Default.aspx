<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridSample.Main" %>

<%@ Register Src="~/UserControll/ComPager.ascx" TagPrefix="uc1" TagName="ComPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-search"></i>جستجو</h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
            </span>
        </div>

        <div class="widget-body">
            <div class="dataTables_wrapper" role="grid">
                <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch" CssClass="form-inline">
                    <div class="row-fluid">
                        <div class="control-group clearfix">
                            <div class="span4">
                                <label class="control-label" for="<%= txtFirstname.ClientID %>">
                                    نام : 
                                </label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFirstname" CssClass="span12 limited" data-maxlength="255" runat="server" placeholder='جستجو بر اساس نام'></asp:TextBox>
                                </div>
                            </div>
                            <div class="span4">
                                <label class="control-label" for="<%= txtLastName.ClientID %>">
                                    نام خانوادگی :
                                </label>
                                <div class="controls">
                                    <asp:TextBox ID="txtLastName" CssClass="span12" runat="server" placeholder="جستجو بر اساس نام خانوادگی"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span4">
                                <label class="control-label" for="<%= txtFatherName.ClientID %>">
                                    نام پدر : 
                                </label>
                                <div class="controls">
                                    <asp:TextBox ID="txtFatherName" CssClass="span12 limited" runat="server" placeholder='جستجو بر اساس نام پدر'></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="control-group clearfix">
                            <div class="span4">
                                <label class="control-label" for="<%= txtNationalID.ClientID %>">
                                    کد ملی :
                                </label>
                                <div class="controls">
                                    <asp:TextBox ID="txtNationalID" CssClass="span12" runat="server" placeholder='جستجو بر اساس کد ملی'></asp:TextBox>
                                </div>
                            </div>
                            <div class="span4">
                                <label class="control-label" for="<%= txtBirthPlace.ClientID %>">
                                    محل تولد : 
                                </label>
                                <div class="controls">
                                    <asp:TextBox ID="txtBirthPlace" CssClass="span12 limited" data-maxlength="255" runat="server" placeholder='جستجو بر اساس محل تولد'></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="control-group clearfix">
                            <div class="span6">
                                <label class="control-label" for="<%= drpSortBy.ClientID %>">
                                    مرتب سازی بر اساس  : 
                                </label>
                                <div class="controls">
                                    <asp:DropDownList ID="drpSortBy" CssClass="span12" runat="server">
                                        <asp:ListItem Value="FirstName" Text="نام"></asp:ListItem>
                                        <asp:ListItem Value="LastName" Text="نام خانوادگی"></asp:ListItem>
                                        <asp:ListItem Value="FatherName" Text="نام پدر"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="span6">
                                <label class="control-label" for="<%= drpSortType.ClientID %>">
                                    نوع مرتب سازی   : 
                                </label>
                                <div class="controls">
                                    <asp:DropDownList ID="drpSortType" CssClass="span12" runat="server">
                                        <asp:ListItem Value="Des" Text="نزولی"></asp:ListItem>
                                        <asp:ListItem Value="Asc" Text="صعودی"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="control-group clearfix">
                            <div class="span9"></div>
                            <div class="controls span3">
                                <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary span12" runat="server" OnClick="btnSearch_Click">
		                                <i class="icon-search bigger-110"></i>
		                                جستجو
                                </asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>

    <div class="widget">
        <div class="widget-title">
            <h4><i class="icon-th-list"></i>لیست افراد</h4>
            <span class="tools">
                <a href="javascript:;" class="icon-chevron-down"></a>
            </span>

            <span class="tools myTool pageSize">
                <small>
                    <span>نمایش</span>
                    <asp:DropDownList CssClass="input-mini" ID="drpPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpPageSize_SelectedIndexChanged">
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="20" Selected="True">20</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                        <asp:ListItem Value="All">همه</asp:ListItem>
                    </asp:DropDownList>
                    <span>رکورد</span>
                </small>
            </span>

        </div>

        <div class="widget-body">
            <div class="dataTables_wrapper" role="grid">
                <table class="table table-bordered table-hover ">
                    <tr>
                        <th class="span1">
                            <i class="icon-list-ol"></i>
                        </th>

                        <th class="span3">
                            <i class="icon-bullhorn"></i>
                            نام 
                        </th>
                        <th class="span3">
                            <i class="icon-bookmark"></i>
                            نام خانوادگی
                        </th>
                        <th class="span2">
                            <i class="icon-bookmark"></i>
                            نام پدر
                        </th>
                        <th class="span2">
                            <i class="icon-bookmark"></i>
                            شماره ملی
                        </th>
                        <th class="span2">
                            <i class="icon-calendar"></i>
                            محل تولد 
                        </th>
                    </tr>
                    <asp:ListView ID="lstPerson" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="lblID" runat="server" Value='<%# Eval("xID") %>' />
                                    <%#(( Container.DataItemIndex + 1)+(Request.QueryString["Page"]==null?0:(Request.QueryString["Page"].ToInt()-1)*(drpPageSize.SelectedValue.ToInt())) )%>
                                </td>

                                <td>
                                    <%# Eval("xFirstName") %>
                                </td>
                                <td>
                                    <%# Eval("xLastName") %>
                                </td>
                                <td>
                                    <%# Eval("xFatherName") %>
                                </td>
                                <td>
                                    <%# Eval("xNationalID") %>
                                </td>
                                <td>
                                    <%# Eval("xBirthCartPlace") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>

                <div class="row-fluid">
                    <div class=" paging_bootstrap pagination">
                        <uc1:ComPager runat="server" ID="ComPager" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
