using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlowConditionalStatement
{

    //    ## Task 1. Class Chef in C&#35;
    //*	Refactor the following class using best practices for organizing straight-line code:

        public class Chef
        {
            private Bowl GetBowl()
            {   
                //... 
            }
            private Carrot GetCarrot()
            {
                //...
            }
            private void Cut(Vegetable potato)
            {
                //...
            }  
            public void Cook()
            {    
                Bowl bowl;
                bowl = GetBowl();

                Potato potato = GetPotato();
                Peel(potato);
                Cut(potato);
                bowl.Add(potato);

                Carrot carrot = GetCarrot();
                Peel(carrot);
                Cut(carrot);
                bowl.Add(carrot);
                        
                
            }
            private Potato GetPotato()
            {
                //...
            }
        }

    }
