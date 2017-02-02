## Android Course

### 1. Course infroduction
### 2. Infroduction to Java

CLR in C# = JVM (Java virtual Machine)  
Задължително в Main метода да има (String[] args)  
Java 8 - means the version is 1.8.xxxx  
`javac` - java compile (JDK) -> compiles to .class  
The class and file name should match   
Should have JDK and JRE - by defaut JDK comes with JRE   
Should have JAVA_HOME Variable with same value as Path

### 3. Java Basics

`Gradle` equals to  npm in Node and NuGet in .NET  
`sout` = system out  
`String, boolean`  
`int` and `Integer` - The difference is :
- You use: `new ArrayList<Integer>();` ('Object Wrapper')
- **But** you cannot use: `new ArrayList<int>();` 

For in syntax: for(String name: names) { // code }  
int number = 9_000_000; // underlines are skipped  
`import java.util.*` - all from "util" - not good practice  
```Java
Function<Integer, void> f =  (param) -> {
    // do something 
	return null;
}
```

Map<> = Dicrioanry in C#  
There is no `List[0] = value`; i.e. no index overload.

### 4. Steaming API
`Arrays.stream(numbers).forEach(System.out::println) // n -> system.out.println(n)`  
Simple arrays should be called like above. Otherwise:  
` list.stream()`  
`.collect(Collectors.toCollection())` ends the stream 

`Arrats.sort(numbers, Comparator)` // numbers is Numbers[] **!!! not `int[]`**

Anonnymus class - inline impements of an interface. cannot be replaced with lambda or method reference. (Needs a hack for android)

### 5. OOP in JAVA
`checkstyle` plugin - code format  
private classes can have different filenames.  
all instance methods are virtual - overridable  
Interfaces have public accessor on methods.  
Interfaces can have static method implementations  

```Java
static String doSomthing() {
     return ""; 
} 
```
```Java
// in Interface
default boolean save() {
      
}
```


may contains fields  
anounimous classs for event handlers  
<T extends ICanMove> T[] GetAllMoveObjects();

### 6. Android Setup Enviroment

AVD - Android Virtual Device

### 7. Introducing to Android

`Gradle` - pulls packages and builds project

`Java folder` - code 
- packages - tests (jUnit), one of the packages is our code.  

Need to click on the file name not on the line - in order to open the file

`Activity` - Visualization, one screen, 
 - extends `AppCompactActivity`(recommended) or `Activity`
 - no constructor(Android OS don't use it), instead use `onCreate()` @Overload
 - `onCreate()` when Activity will be shown on the screen. 
 - in `onCreate()` body we call `super.onCreate(savedInstance)` to save the state of the activity.
 (Example when typing long text and suddenly app is switched, the text will be saved in the input.)
 - in `onCreate()` body we call `setContentView(R.layout.activity_item_list)`- to set which view to render. (`R` is resources - `res` folder)
 - above two are mandotorary.
 - `Fragment` is mini activity that can be used in other activities
 - `android:layout_width` and `android:layout_height` have two values:
    - `match_parent` - takes all width/height from parent. (100%)
    - `wrap_content` - takes what it needs to be visualizated. I.e. not all.
 - measure is in `dpi` - like 5dp 
 - to access resources from .xml layout use `android:Text="@strings/resource_name"`. It is like a constants.
    - Good option for multi-lingual.
    - Removes magic (hard-coded) values in code.
 - Build in logger: `Log.d("Info", "It works!");`
 `Manifest` folder  
 - configuration in application
 - can configure witch is the first activity in the app
 - `<uses-featute>` hardware features like camera. user should allow this permission.
 - `<uses-permission>` software features like internet.

In Gradle :
 default config: { jackOptions: enabled true}

Service - new thread, async background worker. No UI. 
Content Providers - sharing data between two applications, like photo sharing.  
Adapter - Java code to view  
Fragment - part of activity, may contain content View or Not.  
   - `onCreateView()`
Loaders 