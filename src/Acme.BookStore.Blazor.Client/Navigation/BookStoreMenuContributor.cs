﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Acme.BookStore.Localization;
using Acme.BookStore.Permissions;
using Acme.BookStore.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.Users;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.Identity.Blazor;

namespace Acme.BookStore.Blazor.Client.Navigation;

public class BookStoreMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public BookStoreMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        //else if (context.Menu.Name == StandardMenus.User)
        //{
        //    await ConfigureUserMenuAsync(context);
        //}
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BookStoreResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "BookStore.Home",
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );

        var bookStoreMenu = new ApplicationMenuItem(
            "BooksStore",
            l["Menu:BookStore"],
            icon: "fa fa-book"
        );

        context.Menu.AddItem(bookStoreMenu);
        bookStoreMenu.AddItem(new ApplicationMenuItem(
            "BooksStore.Books",
            l["Menu:Books"],
            url: "/books"
        ).RequirePermissions(BookStorePermissions.Books.Default));

        context.Menu.AddItem(new ApplicationMenuItem(
        "BooksStore.Authors",
        l["Menu:Authors"],
        url: "/authors"
    ).RequirePermissions(BookStorePermissions.Books.Default));

    }

}
