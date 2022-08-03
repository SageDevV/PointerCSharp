//No XML, colocar uma tag que desabilita a segurança do código.

int[] numbers = new int[] { 10, 20, 30, 40 };

//Bloco unsafe nos permite trabalhar com ponteiros em .NET
//unsafe
//{
//    fixed (int* i = &numbers[0])
//    {
//        int x = 0;

//    //Referencia no fluxo da aplicação.
//    reference:
//        //Console.WriteLine(i[x + 1]);

//        if (x == numbers.Length - 1) return;

//        x++;

//        //Retornar para referencia anterior
//        goto reference;
//    }
//}

Pointer pointer;

unsafe
{
    Pointer* p = &pointer;
    p->Value = 100;
    p->Value2 = 100;
    p->Value3 = 100;
    p->Right();
    p->Left();
    Console.WriteLine("Value in local memory " + p[0].Value);
    Console.WriteLine("Value in local memory " + p[0].Value2);
    Console.WriteLine("Value in local memory " + p[0].Value3);
}

public unsafe struct Pointer
{
    public int Value;
    public int Value2;
    public int Value3;

    public void Right()
    {
        //Independente de eu apontar para Value, e dizer que o ponteiro aponta para segunda posição, na segunda posição está o Value2
        fixed (int* i = &Value)
            ++i[1];
    }
    
    public void Left()
    {
        //Independente de eu apontar para Value, e dizer que o ponteiro aponta para terceira posição, na terceira posição está o Value3
        fixed (int* i = &Value)
            --i[2];
    }
}
