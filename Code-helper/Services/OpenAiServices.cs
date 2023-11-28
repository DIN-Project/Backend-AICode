
using Microsoft.Extensions.Options;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAIApp.Configurations;

namespace OpenAIApp.Services;

public class OpenAiServices : IOpenAiServices
{
    private readonly OpenAiConfig _openAiConfig;

    public OpenAiServices(IOptionsMonitor<OpenAiConfig> optionsMonitor)
    {
        _openAiConfig = optionsMonitor.CurrentValue;
    }

    public async Task<string> CodeChecker(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var result = await api.Completions.CreateCompletionAsync(
            new CompletionRequest(text, model: Model.ChatGPTTurbo, temperature: 0.1));
        return result.Completions[0].Text;
    }

    public async Task<string> CompleteSentence(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var result = await api.Completions.GetCompletion(text);
        return result; 
    }

    public async Task<string> FixCode(string code)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var  chat = api.Chat.CreateConversation();
        chat.AppendSystemMessage("You are a bot that helps programmers fix their code and give advice.");
        chat.AppendUserInput(code);
        var response = await chat.GetResponseFromChatbotAsync();
        return response;    
    }
}