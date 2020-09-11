using System;
using System.Collections.Generic;
using System.Text;
using TemporaryProj.Builder.Abstract_House_Builder;

namespace TemporaryProj.Builder.Concrete_House_Builder
{
    class House
    {
        public void ShowHouse()
        {
            DrawRoof();
            floors.ForEach((AbstractFloor floor) =>
            {
                Console.WriteLine(" ##############");
                DrawFloor(floor);
            });
            Console.WriteLine(" ##############");
            basements.ForEach((AbstractBasement basement) =>
            {
                DrawBasement(basement);
            });
            Console.WriteLine("  ############");
        }
        void DrawRoof()
        {
            int a = roof.GetHeight();
            while(a-->0)
            Console.WriteLine("================");
        }
        void DrawFloor(AbstractFloor floor)
        {
            int a = floor.GetHeight();
            while (a-- > 0)
                Console.WriteLine(" #__########__#");
        }
        void DrawBasement(AbstractBasement basement)
        {
            int a = basement.GetHeight();
            while (a-- > 0)
            {
                Console.WriteLine("  #          #");
            }
        }
        public AbstractRoof roof { get; set; }
        public List<AbstractFloor> floors { get; set; } = new List<AbstractFloor>();
        public List<AbstractBasement> basements { get; set; } = new List<AbstractBasement>();
    }
}
