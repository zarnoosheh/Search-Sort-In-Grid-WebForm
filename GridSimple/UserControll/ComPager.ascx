<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComPager.ascx.cs" Inherits="Core.SmileAdmin.Components.ComPager" %>

<div class="pager-container">
    <div class="pager pager-c">
        <a data-id="1" class="Previous " href="<%= _GetUrl(1) %>">اولین صفحه</a>

        <%if (_CurrentPage != -1 && (_PagerSize - _CurrentPage) <= 0)
            { %>
        <a data-id="<%= _StartPage-1 %>" class="PageBtn" href="<%=_GetUrl(_StartPage-1)%>">...</a>
        <%} %>


        <%for (int i = _StartPage; i <= _EndPage; i++)
            { %>
        <%if (_CurrentPage == i)
            { %>
        <span data-id="<%= i %>" class="active "><%= i %></span>
        <%}
        else {%>
        <a data-id="<%= i %>" href="<%=_GetUrl(i) %>" class="PageBtn  <%=_CurrentPage == -1 ?"":( _CurrentPage==i?"active":"" )%>"><%= i %></a>
        <%}
            } %>


        <%if (((_PageCount > _PagerSize) && _CurrentPage == -1) || (_CurrentPage != -1 && (_LastPage - _CurrentPage) >= _PagerSize))
            { %>
        <a data-id="<%= _EndPage+1 %>" class="PageBtn" href="<%=_GetUrl(_EndPage+1) %>">...</a>
        <%} %>


        <a data-id="<%=_LastPage %>" class="Next " href="<%=_GetUrl(_LastPage)%>">آخرین صفحه</a>
    </div>
</div>
