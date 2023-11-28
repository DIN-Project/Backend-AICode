namespace OpenAIApp.Services;

public interface IOpenAiServices{
    Task<string> CodeChecker (string text);
    Task<string> FixCode (string code);
}