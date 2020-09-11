using System;
namespace TemporaryProj.Facade{
    class ComplicatedClass1{
        public void MethodA(){

        }
    }
    class ComplicatedClass2{
        public void MethodB(){
            
        }
    }
    class ComplicatedClass3{
        public void MethodC(){
            
        }
        public void MethodD(){
            
        }
    }
    class Facade{
        public Facade(ComplicatedClass1 class1, ComplicatedClass2 class2, ComplicatedClass3 class3)
        {
            this.class1 = class1;
            this.class2 = class2;
            this.class3 = class3;
        }
        protected ComplicatedClass1 class1;
        protected ComplicatedClass2 class2;
        protected ComplicatedClass3 class3;
        public void MethodABC(){
            class1.MethodA();
            class2.MethodB();
            class3.MethodC();
        }
        public void MethodCD(){
            class3.MethodC();
            class3.MethodD();
        }
    }
}