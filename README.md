# SimpleTextMerger

SimpleTextMerger is an open source library for replacing certain keys in the text with values from the provided object.

At the first step use MergerBuilder to configure text IMerger object, that will select keys from source text and replace them by values from provided object.
```sh
    var builder = new MergeBuilder();
    var merger = builder.AddDefaultSelectorFor(object).Build();
```
Then you can use Merge on your text
```sh
    var result = merger.Merge(text);
```
Sometimes we can`t use default selectors like ```'Person.Address.Street'```.
For example we need to select higher value from array and replace particular key by this value.
For this approach we can use FunctionalSelector, or crete specific one by implementing ISelector interface and then configuring this in MergerBuilder.
Also we need to add token provider that parses this specific key from text.
```sh
    var builder = new MergeBuilder();
    var merger = builder
                .AddTokenProvider(new RegexTokenProvider())
                .AddTokenProvider(new CustomKeyTokenProvider())
                .AddDefaultSelectorFor(obj)
                .AddSelector(new FunctionalSelector(token => FuncSelector(token, obj)))
                .Build();

     /* .... */
 
    private static string FuncSelector(string token, object obj)
    {
      if (token is "$HigherValue") return obj.SomeArray.Max();
      
      return null;
    }
```
Also we can specify the behavior of merger when value is null or key is not found
```sh
    SelectorBehavior.Ignore  //  just ignores missed key and lefts as it is
    SelectorBehavior.SetEmpty //  replacing missed key by empty value
    SelectorBehavior.Exception //  throws exception
```
Example of code:
```sh
    var builder = new MergeBuilder();

    var merger = builder.AddDefaultSelectorFor(obj)
    .SetMergeBehavior(SelectorBehavior.Ignore)
    .Build();
 
    var result = merger.Merge(text);
```