###WebWindow
Example window with method helloFromJS, that called from js (see /index.html)

For recieving events from js, create any ScriptableObject and call WebView.defineScriptObject("someName", scriptableobject)
Called method should have last argument with type - System.Object. It's callback, without it script doesn't work
Possible type for other arguments only System.String

For sending events from js see index.html

###WebProvider
Wrapper internal tools for drawing WebView

TL;DR;
