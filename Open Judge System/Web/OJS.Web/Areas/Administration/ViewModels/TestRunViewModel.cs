﻿namespace OJS.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using OJS.Data.Models;
    using TestRunModel = OJS.Data.Models.TestRun;

    public class TestRunViewModel
    {
        public static Expression<Func<TestRunModel, TestRunViewModel>> FromTestRun
        {
            get
            {
                return testRun => new TestRunViewModel
                {
                    Id = testRun.Id,
                    ExecutionResult = testRun.ResultType,
                    MemoryUsed = testRun.MemoryUsed,
                    TimeUsed = testRun.TimeUsed,
                    SubmissionId = testRun.SubmissionId,
                    ProblemName = testRun.Test.Problem.Name,
                    ExecutionComment = testRun.ExecutionComment,
                    CheckerComment = testRun.CheckerComment,
                };
            }
        }

        public int Id { get; set; }

        public int TimeUsed { get; set; }

        public long MemoryUsed { get; set; }

        public int SubmissionId { get; set; }

        public string ProblemName { get; set; }

        public string ExecutionComment { get; set; }

        public string CheckerComment { get; set; }

        public DateTime Date { get; set; }

        public TestRunResultType ExecutionResult { get; set; }
    }
}