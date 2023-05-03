using Microsoft.SemanticKernel;
using MySemanticKernelFirstProject.Enums;
using MySemanticKernelFirstProject.Extensions;
using Microsoft.SemanticKernel.CoreSkills;
using Microsoft.SemanticKernel.Memory;
using System.Reflection;
using System.Security.Cryptography;

namespace MySemanticKernelFirstProject
{
    public class Memories
    {
        public async Task<IKernel> CreateMemories() {

            var apiKey = "ENTER_YOUR_API_KEY";

            var kernel = new KernelBuilder()
            .Configure(c =>
            {
                    c.AddOpenAITextEmbeddingGenerationService("ada", "text-embedding-ada-002", apiKey);
                    c.AddOpenAITextCompletionService("davinci", "gpt-3.5-turbo", apiKey);
            })
            .WithMemoryStorage(new VolatileMemoryStore())
            .Build();

            var MemoryCollectionName = MemoriesCollectionsEnum.AboutMe.GetDescription();
            kernel.ImportSkill(new TextMemorySkill()); 


            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "1", text: "My name is Kato");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "2", text: "I sleep 16 hours a day");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "3", text: "All I do is sleep eat and purr");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "4", text: "I live at my moms house");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "5", text: "I have 5 brothers and 3 sisters");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "6", text: "I am 3 years old");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "7", text: "I live on 9th floor");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "8", text: "I have 6 lives out of 9 left");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "9", text: "I love eating tuna");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "10", text: "I like scratcing");
            await kernel.Memory.SaveInformationAsync(MemoryCollectionName, id: "11", text: "I like drinking milk");

            return kernel;
        }
    }
}
