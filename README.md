
### What is PagedListExtensions?

I wrote a small library to use for easier pagination

### How do I get started?

In your application code

```csharp
var result = source.ToPagedList(pageNumber, pageSize);
var result = source.ToPagedList(x => new Foo() {Id= x.Id, Code= x.Code }, pageNumber, pageSize);
```

Async Method

```csharp
var result = await source.ToPagedListAsync(pageNumber, pageSize);
var result = await source.ToPagedListAsync(x => new Foo() {Id= x.Id, Code= x.Code }, pageNumber, pageSize);
```

### Where can I get it?

First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [PagedListExtensions](https://www.nuget.org/packages/PagedListExtensions/) from the package manager console:
```
PM> Install-Package PagedListExtensions
```