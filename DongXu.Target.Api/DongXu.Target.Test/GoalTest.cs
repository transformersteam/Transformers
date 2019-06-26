using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using DongXu.Target.Api.Controllers.ExecuteController;
using DongXu.Target.Repository.Execute;
using DongXu.Target.Model.Dto;

namespace DongXu.Target.Test
{
    [TestClass]
    public class GoalTest
    {
        private GoalRepository goal = new GoalRepository();

        [TestMethod]
        public void TestMethod1()
        {
            var list = goal.GetGoalList(1);
            Assert.IsNotNull(list);
        }
    }
}
