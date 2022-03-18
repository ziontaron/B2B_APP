using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusable
{
    interface ICRUD<Entity> where Entity:BaseEntity 
    {
        CommonResponse Create(Entity e);
        CommonResponse ReadbyName(Entity e);
        CommonResponse ReadbyId(Entity e);
        List<Entity> ReadAll();
        CommonResponse Update(Entity e);
        CommonResponse Delete(Entity e);

    }
}
