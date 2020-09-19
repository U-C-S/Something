using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Something
{
    public class Branch
    {
        public string consequences { get; set; }
        public string choiceOne { get; set; }
        public string choiceTwo { get; set; }
        public Action oneFn;
        public Action twoFn;
        public string choiceSecret { get; set; }


        public void intialContext()
        {
            consequences = "This is a Branching Story line Game. You choose the choices based on the story and The story responds to your choice. Do you Understand?";
            choiceOne = "Yes";
            choiceTwo = "No";
            oneFn = Start;
            twoFn = NotUnderstood;
        }
        public void NotUnderstood()
        {
            consequences = "Come on!. You just choose the choices based on the story and The story responds to your choice. Do you Understand? Sorry, Only yes options Available";
            choiceOne = "Yes";
            choiceTwo = "Yes";
            oneFn = twoFn = Start;
        }

        public void Start()
        {
            consequences = "You went to a restaurent. You were given the choice of Coffee or Tea";
            choiceOne = "Coffee";
            choiceTwo = "Tea";
            oneFn = Coffee;
            twoFn = Tea;
        }

        public void Coffee()
        {
            consequences = "You ordered the Coffee";
            choiceOne = "Drink it";
            choiceTwo = "Spill it on Table and Leave the Resta";
            oneFn = CoffeeNotGood;
            twoFn = LeaveTheResta;
        }
        public void CoffeeNotGood()
        {
            consequences = "You drank the coffee. Then you realised the coffee isn't good. So You decided to Leave and try another Resta";
            choiceOne = "Leave";
            choiceTwo = "Leave";
            oneFn = intialContext;
            twoFn = LeaveTheResta;
        }

        public void Tea()
        {
            consequences = "Oops, Accidentally the Tea is Spilled on the table";
            choiceOne = "Say sorry!";
            choiceTwo = "Get out of Resta";
            oneFn = OutOfTea;
            twoFn = LeaveTheResta;
        }
        public void OutOfTea()
        {
            consequences = "Sorry! The Waitress says the Resta dont have anymore tea leaves. Suggests you to try Coffee or Find an another Resta";
            choiceOne = "Order Coffee";
            choiceTwo = "Leave the Resta";
            oneFn = Coffee;
            twoFn = LeaveTheResta;
        }
        public void LeaveTheResta()
        {
            consequences = "You leave the Resta to find another Resta";
            choiceOne = "Next";
            choiceTwo = "Next";
            oneFn = twoFn = intialContext;
        }

    }
}
