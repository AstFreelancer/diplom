using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Athelas
{
    class Command
    {
        public int id=0;//1 - добавление, 2 - удаление, 3 - правка, 4 - перенос в базу, 5 - возвращение из базы
        public ArrayList items = new ArrayList();
    }
}
