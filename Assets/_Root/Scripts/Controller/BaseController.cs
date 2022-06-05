using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    private List <IDisposable> _disposables = new List<IDisposable>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        DisposeDisposables();
        DisposeGameObjects();

        OnDispose();
    }

    private void DisposeDisposables()
    {
        if (_disposables == null)
            return;
        foreach (IDisposable disposable in _disposables) 
            disposable.Dispose();
        _disposables.Clear();
    }

    private void DisposeGameObjects()
    {
        foreach (GameObject gameObject in _gameObjects)
            Object.Destroy(gameObject);

        _gameObjects.Clear();
    }

    protected virtual void OnDispose()
    { }

    protected void AddController(BaseController baseController) => 
        AddDisposable(baseController);
    protected void AddRepository(IRepository repository)=>
        AddDisposable(repository);
    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }
    private void AddDisposable(IDisposable disposable)
    {
        _disposables ??= new List<IDisposable>();
        _disposables.Add(disposable);

    }

    protected void Log(string message) =>
        Log(WrapMessage(message));

    protected void Error(string message) =>
        Log(WrapMessage(message));

    private string WrapMessage(string message) =>
        $"[{GetType().Name}] {message}";
}