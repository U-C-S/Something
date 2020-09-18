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
        public string choiceSecret { get; set; }
        public string skipcode;

        public void intialContext()
        {
            consequences = "This is a Branching Story line Game. You choose the choices based on the story and The story responds to your choice. Do you Understand?";
            choiceOne = "Yes";
            choiceTwo = "No";
        }

        public void NotUnderstood()
        {
            consequences = "Come on!. You just choose the choices based on the story and The story responds to your choice. Do you Understand? Sorry, Only yes options Available";
            choiceOne = "Yes";
            choiceTwo = "Yes";
        }

        public void Start()
        {
            consequences = "You went to a restaurent. You were given the choice of Coffee or Tea";
            choiceOne = "Coffee";
            choiceTwo = "Tea";
        }


    }
}
