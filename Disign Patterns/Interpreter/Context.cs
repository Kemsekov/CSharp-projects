namespace CSharp_projects.Disign_Patterns.Interpreter
{
    /*
    Кароче сделай так, чтоб строка подающаяся на вход сплитилась через пробелы
    Потом ты определяешь что за слово через hash-функцию и в зависимости от 
    этого уже строишь дерево выражения
    */
    public class Context
    {
        public string Source{get;set;}
        public string[] Vocabulary{get;set;}
        public bool Result{get;set;}
        public int Position{get;set;} = 0;
    }
}