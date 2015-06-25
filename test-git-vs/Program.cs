using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_git_vs
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Context(new ConcreteStateA());
            
            ctx.Request();
            ctx.Request();
            ctx.Request();
            ctx.Request();
            ctx.Request();

            Console.WriteLine("");
        }
    }
    
    public class Context 
    {
        private State _state;
        
        public Context(State state) {
            _state = state;
        }    
        
        public State State {
            get { return _state; }
            set 
            { 
                _state = value;
                Console.WriteLine(_state.GetType().Name); 
            }
        }
        public void Request() {
            State.Handle(this);
        }
    }
    
    public abstract class State {
        public abstract void Handle(Context context);
    }
    
    public class ConcreteStateA : State {
        public override void Handle(Context context) {
            context.State = new ConcreteStateB();
        }
    }
   
    public class ConcreteStateB : State {
        public override void Handle(Context context) {
            context.State = new ConcreteStateA();
        }
    }    
}
