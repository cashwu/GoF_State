using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    public class Agent
    {
        public static readonly int HEALTH_LOW_LIMIT = 70;
        public static readonly int INJURED_LOW_LIMIT = 1;
        public static readonly int DEAD_LOW_LIMIT = 0;

        private static int MAX_HP = 100;

        private IAgentState _currentState = null;

        private int _HP = 0;

        public Agent()
        {
            _currentState = new Health();
            _HP = MAX_HP;
        }

        public int getHP()
        {
            return _HP;
        }

        public IAgentState getState()
        {
            return _currentState;
        }

        public void search()
        {
            _currentState.search(this);
        }

        public void filgth()
        {
            _currentState.fight(this);
        }

        public void hit(int value)
        {
            _HP = _HP - value;
            _currentState.Hit(this);
        }

        public void heal(int value)
        {
            if (_HP < MAX_HP)
            {
                _HP = _HP + value;
            }

            _currentState.Heal(this);
        }

        public void changeState(IAgentState state)
        {
            _currentState = state;
        }
    }

    public interface IAgentState
    {
        void search(Agent agent);

        void fight(Agent agent);

        void Hit(Agent agent);

        void Heal(Agent agent);
    }

    public class Health : IAgentState
    {
        public void search(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void fight(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void Hit(Agent agent)
        {
            if (agent.getHP() < Agent.INJURED_LOW_LIMIT)
            {
                agent.changeState(new Dead());
            }
            else if (agent.getHP() < Agent.HEALTH_LOW_LIMIT)
            {
                agent.changeState(new Injured());
            }
        }

        public void Heal(Agent agent)
        {
            if (agent.getHP() >= Agent.HEALTH_LOW_LIMIT)
            {
                agent.changeState(new Health());
            }
            else if (agent.getHP() >= Agent.INJURED_LOW_LIMIT)
            {
                agent.changeState(new Injured());
            }
        }
    }

    public class Injured : IAgentState
    {
        public void search(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void fight(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void Hit(Agent agent)
        {
            if (agent.getHP() < Agent.INJURED_LOW_LIMIT)
            {
                agent.changeState(new Dead());
            }
        }

        public void Heal(Agent agent)
        {
            if (agent.getHP() >= Agent.HEALTH_LOW_LIMIT)
            {
                agent.changeState(new Health());
            }
        }
    }

    public class Dead : IAgentState
    {
        public void search(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void fight(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void Hit(Agent agent)
        {
            throw new NotImplementedException();
        }

        public void Heal(Agent agent)
        {
            if (agent.getHP() >= Agent.HEALTH_LOW_LIMIT)
            {
                agent.changeState(new Health());
            }
            else if (agent.getHP() >= Agent.INJURED_LOW_LIMIT)
            {
                agent.changeState(new Injured());
            }
        }
    }
}