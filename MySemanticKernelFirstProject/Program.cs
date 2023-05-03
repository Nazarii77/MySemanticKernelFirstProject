using MySemanticKernelFirstProject;
using MySemanticKernelFirstProject.Enums;
using MySemanticKernelFirstProject.Extensions;

var memories = new Memories();

var kernel = await memories.CreateMemories();

Console.WriteLine("I am a talking cat simulator, ask me any question. To exit press 1");


while (true)
{
    var input = Console.ReadLine();

    if (input == null || input.Equals("1", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
    else
    {
        var response = await kernel.Memory.SearchAsync(MemoriesCollectionsEnum.AboutMe.GetDescription(), input).FirstOrDefaultAsync();

        if (response == null) {
            Console.WriteLine("I don`t know");
        }
        else
        {
            Console.WriteLine(response?.Metadata.Text);
        }
        
    }
}


