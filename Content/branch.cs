using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    public class Branch
    {
        public string Consequences { get; set; }
        public string ChoiceBtn1 { get; set; }
        public string ChoiceBtn2 { get; set; }
        public Action ChoseOne;
        public Action ChoseTwo;
        public string ChoiceSecret { get; set; }


        public void intialContext()
        {
            Consequences = "This is a Branching Story line Game. You choose the choices based on the story and The story responds to your choice. Do you Understand?";
            ChoiceBtn1 = "Yes";
            ChoiceBtn2 = "No";
            ChoseOne = Start;
            ChoseTwo = NotUnderstood;
        }
        public void NotUnderstood()
        {
            Consequences = "Come on!. You just choose the choices based on the story and The story responds to your choice. Do you Understand? Sorry, Only yes options Available";
            ChoiceBtn1 = "Yes";
            ChoiceBtn2 = "Yes";
            ChoseOne = ChoseTwo = Start;
        }

        public void Start()
        {
            Consequences = "You went to a restaurent. You were given the choice of Coffee or Tea";
            ChoiceBtn1 = "Coffee";
            ChoiceBtn2 = "Tea";
            ChoseOne = Coffee;
            ChoseTwo = Tea;
        }

        public void Coffee()
        {
            Consequences = "You ordered the Coffee";
            ChoiceBtn1 = "Drink it";
            ChoiceBtn2 = "Spill and Leave";
            ChoseOne = CoffeeNotGood;
            ChoseTwo = LeaveTheResta;
        }
        public void CoffeeNotGood()
        {
            Consequences = "You drank the coffee. Then you realised the coffee isn't good. So You decided to Leave and try another Resta";
            ChoiceBtn1 = "Leave";
            ChoiceBtn2 = "Leave";
            ChoseOne = intialContext;
            ChoseTwo = LeaveTheResta;
        }

        public void Tea()
        {
            Consequences = "Oops, Accidentally the Tea is Spilled on the table";
            ChoiceBtn1 = "Say sorry!";
            ChoiceBtn2 = "Get out of Resta";
            ChoseOne = OutOfTea;
            ChoseTwo = LeaveTheResta;
        }
        public void OutOfTea()
        {
            Consequences = "Sorry! The Waitress says the Resta dont have anymore tea leaves. Suggests you to try Coffee or Find an another Resta";
            ChoiceBtn1 = "Order Coffee";
            ChoiceBtn2 = "Leave the Resta";
            ChoseOne = Coffee;
            ChoseTwo = LeaveTheResta;
        }
        public void LeaveTheResta()
        {
            Consequences = "You leave the Resta to find another Resta";
            ChoiceBtn1 = "Next";
            ChoiceBtn2 = "Next";
            ChoseOne = ChoseTwo = intialContext;
        }

    }
}
