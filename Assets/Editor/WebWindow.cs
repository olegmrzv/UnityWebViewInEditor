using UnityEngine;
using UnityEditor;

public class WebWindow : EditorWindow {
    
    public WebView view;

    public static Rect windowRect = new Rect(100, 100, 800, 600);

    //public string urlText = "http://idflood.github.io/ThreeNodes.js/index_optimized.html";
    public string urlText = "file:///{0}/StreamingAssets/test/index.html";

    [MenuItem("Example/Web Window %#w")]
    public static void load() {
        var window = GetWindow<WebWindow>();

        window.init();
    }


    public void init() {
        this.position = windowRect;

        this.view = new WebView();

        this.view.init(WebProvider.getView(this), new Rect(0, 22, this.position.width, this.position.height), false);

        this.view.defineScript("window.unityScriptObject", this);
        this.view.allowRightClickMenu(true);
        this.view.setDelegateObject(this);

        //this.view.loadURL(this.urlText);
        this.view.loadFile(string.Format(this.urlText, Application.dataPath));
    }


    public void helloFromJS(string message, object callback) {
        Debug.LogFormat("message from js: {0}", message);
        
        var wrap = new CallbackWrapper(callback);
        if (message.Contains("hello")) {
            wrap.Send("hello, js");
        }
        else {
            wrap.Send("hmm...");
        }
    }

    public void OnGUI() {
        if(this.view == null){ return; }

        if (Event.current.type == EventType.Layout) {
            this.view.setRect(new Rect(0, 22, this.position.width, this.position.height));
        }
    }
}