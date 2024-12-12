using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Code.Scenes
{
  public class LoadingScreen : MonoBehaviour
  {
    [SerializeField]
    private CanvasGroup _canvas;

    private void Start() =>
      DontDestroyOnLoad(gameObject);

    public async UniTask Appear() =>
      await _canvas.DOFade(1, MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());

    public async UniTask Fade() =>
      await _canvas.DOFade(0, MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());
  }
}