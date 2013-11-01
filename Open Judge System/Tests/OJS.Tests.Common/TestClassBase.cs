﻿namespace OJS.Tests.Common
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    using OJS.Data;
    using OJS.Tests.Common.DataFakes;

    public abstract class TestClassBase
    {
        protected IOjsData EmptyOjsData;

        protected IOjsData OjsData;

        protected TestClassBase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FakeOjsDbContext, DatabaseConfiguration>());
            OjsData = new OjsData(new FakeOjsDbContext());
            InitializeEmptyOjsData();
        }

        protected void InitializeEmptyOjsData()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<FakeEmptyOjsDbContext>());
            var fakeEmptyOjsDbContext = new FakeEmptyOjsDbContext();
            fakeEmptyOjsDbContext.Database.Initialize(true);
            this.EmptyOjsData = new OjsData(fakeEmptyOjsDbContext);
        }
    }
}
