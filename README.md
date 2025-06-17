# Auto Hook

Auto Hook is a property drawer that automagically assigns a reference to your field.

## Usage
Using Auto Hook is easy. You just have to add the `[AutoHook]` attribute to any field that wants a component and it'll try to assign it.

```csharp
public class Foo : MonoBehaviour
{
    [SerializeField, AutoHook]
    private Rigidbody rigidbody;

    [...]
}
```

There's some extra options that you can configure

| Option              	| Description                                                                                                                                                                                                                                                                                                                                                                                                   	|
|---------------------	|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| SearchArea          	| **Default**<br>Self `GetComponent`<br><br>**Parent**<br>Matches `GetComponentInParent`<br><br>**Children**<br>Matches `GetComponentInChildren`<br><br>**DirectChildrenOnly**<br>Iterates over the direct children of the current object only, ignoring itself and any children below that<br><br>**AllChildrenOnly**<br>Iterates over all children of the current object recursively, ignoring only itself<br><br>**WholeScene**<br>Iterates depth first over all objects in the same scene as the gameObject this field appears on 	|
| HideWhenFound       	| Reduces the size of the property to 0 when a matching component has been found                                                                                                                                                                                                                                                                                                                                	|
| ReadOnlyWhenFound   	| Marks the property as read-only when a matching component has been found                                                                                                                                                                                                                                                                                                                                      	|
| StopSearchWhenFound 	| Stops calling GetComponent (or other variants) when a matching component has been found. This is useful if you have many `[AutoHook]` usages in your file                                                                                                                                                                                                                                                     	|

## Support
**Auto Hook** is originally made by [LotteMakesStuff](https://github.com/LotteMakesStuff) and can be found [here](https://gist.github.com/LotteMakesStuff/d6a9a4944fc667e557083108606b7d22). 
 
 You can support **LotteMakesStuff** through her ko-fi or by becoming her Patreon
  
  [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/A08215TT) <a href='https://www.patreon.com/bePatron?u=7061709' target='_blank'><img height='35' style='border:0px;height:46px;' src='https://c5.patreon.com/external/logo/become_a_patron_button@2x.png' border='0' alt='Become a Patron!' /></a>

 
**This version** is forked from a version made by [Thundernerd](https://github.com/Thundernerd) and can be found [here](https://github.com/Thundernerd/Unity3D-AutoHook).

 You can support **Thundernerd** through their ko-fi

  [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/J3J11GEYY)

## Contributing
Pull requests are welcomed. Please feel free to fix any issues you find, or add new features.
