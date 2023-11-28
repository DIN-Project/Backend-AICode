namespace OpenAIApp.Services;

public interface IOpenAiServices{
    Task<string> CompleteSentence (string text);
    Task<string> CodeChecker (string text);
    Task<string> FixCode (string code);
}