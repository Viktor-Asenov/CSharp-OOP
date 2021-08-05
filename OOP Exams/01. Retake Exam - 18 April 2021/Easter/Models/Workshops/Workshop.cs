using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && !egg.IsDone())
            {
                foreach (var dye in bunny.Dyes)
                {
                    if (!dye.IsFinished())
                    {
                        egg.GetColored();
                        dye.Use();
                        bunny.Work();

                        if (egg.IsDone())
                        {
                            return;
                        }
                    }
                }
            }
            
        }
    }
}
