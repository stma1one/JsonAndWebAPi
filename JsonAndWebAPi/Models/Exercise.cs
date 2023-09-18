using System;
using System.Collections.Generic;
using System.Text;

namespace JsonAndWebAPi.Models;


public class Exercise
{
    public int? FirstVal { get; set; }
    public int? SecondVal { get; set; }
    public char? Op { get; set; }
}

public class ExerciseResult
{
    public Exercise? Exercise { get; set; }
    public bool? Success { get; set; }
    public int? Result { get; set; }
}
