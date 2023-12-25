using AutoMapper;
using BLL.DTO;
using BLL.MapperMethods;
using Bogus;
using Bogus.Text;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSite.Tests;

internal static class UnitTestHelper
{
    public static DbContextOptions<NewsSiteContext> GetUnitTestDbOptions()
    {
        var options = new DbContextOptionsBuilder<NewsSiteContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        using (var context = new NewsSiteContext(options))
        {
            FillData(context);
        }

        return options;
    }


    public static IMapper CreateMapperProfile()
    {
        var profile = new MapperProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

        return new Mapper(configuration);
    }

    public static void FillData(NewsSiteContext context)
    {
        context.Authors.AddRange(TestData.Authors);
        context.Rubrics.AddRange(TestData.Rubrics);
        context.Tags.AddRange(TestData.Tags);
        context.News.AddRange(TestData.News);
    }

}
