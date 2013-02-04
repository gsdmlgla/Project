using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    class Updater
    {
        List<Collidable> toCheck = new List<Collidable>();
        List<Entity> allEntities = new List<Entity>();

        public void updateCollision()
        {
            for (int i = 0; i < toCheck.Count; ++i)
            {
                for (int j = 0; j < allEntities.Count; ++j)
                {
                    if (allEntities[j].canCollideWithTeam)
                    {
                        if (toCheck[i] != allEntities[j])
                        {
                            toCheck[i].CheckCollision(allEntities[j]);
                        }
                    }
                }
            }
        }
        public void updateMove()
        {
            for (int i = 0; i < allEntities.Count; ++i)
            {
                allEntities[i].move();
            }
        }
    }
}
