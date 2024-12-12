using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using Code.AssetsManagement;

namespace Code.Scenes
{
  public interface ISceneLoader
  {
    LoadingScreen LoadingScreen { get; }
    UniTask Load(string scene);
  }

  public class SceneLoader : ISceneLoader
  {
    private readonly IBuildersFactory _factory;

    private LoadingScreen _loadingScreen;
    public LoadingScreen LoadingScreen => _loadingScreen ??= _factory.FromResources(Assets.LoadingScreen).Instantiate<LoadingScreen>();

    public SceneLoader(IBuildersFactory factory) =>
      _factory = factory;

    public async UniTask Load(string scene) =>
      await SceneManager.LoadSceneAsync(scene).ToUniTask();
  }
}