// See https://aka.ms/new-console-template for more information
using HasAIsA;
using HasAIsA.Good;
CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

var work = new Work();
var task = work.Method1(CancellationTokenSource.Token);
CancellationTokenSource.Cancel();

await task;


Console.WriteLine("bitti");


public class Work
{

    // Bridge DP
    // Facade DP
    // SOLID DP
    public Task Method1(CancellationToken token)
    {

        File.ReadAllBytes("c://")
        var i = 5 + 5;

        return Task.FromResult(i);


    }
    // 40 sn
    public void Method2()
    {


    }



}























//

//var car1 = new Car1(new NormalRightOrLeft(), new NormalBackward());
//var car2 = new Car2(new NormalRightOrLeft(), new Normal2Backward());

//var train = new Train(new NoRightOrLeft(), new NormalBackward());
//car1.Right();
//car1.Left();
//car1.Back();

//Console.WriteLine("------------");

//car1.SetBehavior(new NoBackward());

//car1.Right();
//car1.Left();
//car1.Back();
//car2.Right();
//car2.Left();
//car2.Back();

//train.Left()