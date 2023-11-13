// See https://aka.ms/new-console-template for more information

using Assessment.Console;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddConsoleReference();
services.AddSingleton<WorkAssessment>();

var workAssessment = services.BuildServiceProvider().GetRequiredService<WorkAssessment>();
workAssessment.StartWork();


