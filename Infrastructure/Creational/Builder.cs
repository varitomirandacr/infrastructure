using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Creational.Builder
{
    public interface IStepBuilder
    {
        void Step1();
        void Step2();
        void Step3();
        void SetSteps();
        Step GetStep();
    }

    public class Step
    {
        public string Step1 { get; set; }
        public string Step2 { get; set; }
        public string Step3 { get; set; }
        public List<string> Steps { get; set; }

        public Step()
        {
            Steps = new List<string>();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Step 1: {Step1}");
            Console.WriteLine($"Step 2: {Step2}");
            Console.WriteLine($"Step 3: {Step3}");
            Console.WriteLine("Steps: ");
            Steps.ForEach(s => Console.WriteLine($"\t {s}"));
        }
    }

    public class StepBuilder : IStepBuilder
    {
        Step step = new Step();

        public void Step1()
        {
            step.Step1 = "Step 1 set";
        }

        public void Step2()
        {
            step.Step2 = "Step 2 set";
        }

        public void Step3()
        {
            step.Step3 = "Step 3 set";
        }

        public void SetSteps()
        {
            step.Steps.Add("Added step 1");
            step.Steps.Add("Added step 2");
            step.Steps.Add("Added step 3");
        }

        public Step GetStep()
        {
            return step;
        }
    }

    public class StepCreator
    {
        private readonly IStepBuilder builder;

        public StepCreator(IStepBuilder builder)
        {
            this.builder = builder;
        }

        public void CreateStep()
        {
            builder.Step1();
            builder.Step2();
            builder.Step3();
            builder.SetSteps();
        }

        public Step GetStep() => builder.GetStep();
    }
}
