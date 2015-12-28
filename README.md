###WebWindow
Example window with method helloFromJS, which is called from js (see /index.html)

1) For recieving events from js  
Create any ScriptableObject and call WebView.defineScriptObject("someName", scriptableobject)    
Called method should have last argument with type - System.Object. It's callback, without it script doesn't work    
Possible type for other arguments only System.String

2) For sending events from js see index.html

###WebProvider
Wrapper internal tools for drawing WebView

TL;DR;
