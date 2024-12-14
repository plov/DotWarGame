using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using Code.SmartDebug;

namespace Code.Scenes
{
  public class LoadingScreen : MonoBehaviour
  {
    [SerializeField]
    private CanvasGroup _canvas;

    private void Start() =>
      DontDestroyOnLoad(gameObject);

    public async UniTask Appear()
    {
      //await _canvas.DOFade(1, MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());
      _canvas.transform.position = new Vector3(-1000, -1000, 0);
      await _canvas.transform.DOMove(new Vector3(960, 540, 0), MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());
    }

    public async UniTask Fade()
    {
      //await _canvas.DOFade(0, MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());
      _canvas.transform.position = new Vector3(960, 540, 0);
      await _canvas.transform.DOMove(new Vector3(-1000, -1000, 0), MainConfig.LoadingScreen).WithCancellation(this.GetCancellationTokenOnDestroy());
    }
      
  }
}