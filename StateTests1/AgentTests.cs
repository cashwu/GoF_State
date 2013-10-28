using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State;

namespace State.Tests
{
    [TestClass()]
    public class AgentTests
    {
        [TestMethod()]
        public void AgentTest()
        {
            Agent agent = new Agent();
            Assert.IsNotNull(agent);

            Assert.AreEqual(typeof(Health), agent.getState().GetType());

            agent.heal(80);
            Assert.AreEqual(100, agent.getHP());
            Assert.AreEqual(typeof(Health), agent.getState().GetType());

            agent.hit(30);
            Assert.AreEqual(typeof(Health), agent.getState().GetType());
            agent.hit(1);
            Assert.AreEqual(typeof(Injured), agent.getState().GetType());

            agent.heal(31);
            Assert.AreEqual(100, agent.getHP());
            Assert.AreEqual(typeof(Health), agent.getState().GetType());

            agent.hit(100);
            Assert.AreEqual(0, agent.getHP());
            Assert.AreEqual(typeof(Dead), agent.getState().GetType());
        }

        //[TestMethod()]
        //public void getHPTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getStateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void searchTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void filgthTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void hitTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void healTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void changeStateTest()
        //{
        //    Assert.Fail();
        //}
    }
}