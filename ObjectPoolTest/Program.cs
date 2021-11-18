using Microsoft.Extensions.ObjectPool;
using ObjectPoolTest;
using System;

var policy = new DefaultPooledObjectPolicy<Foo>();
var pool = new DefaultObjectPool<Foo>(policy);

// 借
var item1 = pool.Get();
// 还
pool.Return(item1);
Console.WriteLine($"item 1: {item1.Id}");

//借第二次
var item2 = pool.Get();
// 还第二次
pool.Return(item2);
Console.WriteLine($"item 2: {item2.Id}");

// 带2大小的池子, 第三个对象并不会池化，而是产生新对象，并销毁。
var poolWithSize = new DefaultObjectPool<Foo>(policy, 2);

var a1 = poolWithSize.Get();
Console.WriteLine($"item 1: {a1.Id}");
var a2 = poolWithSize.Get();
Console.WriteLine($"item 2: {a2.Id}");
var a3 = poolWithSize.Get();
Console.WriteLine($"item 3: {a3.Id}");

poolWithSize.Return(a1);
poolWithSize.Return(a2);
poolWithSize.Return(a3);

var a4 = poolWithSize.Get();
Console.WriteLine($"item 1: {a4.Id}");
var a5 = poolWithSize.Get();
Console.WriteLine($"item 2: {a5.Id}");
var a6 = poolWithSize.Get();
Console.WriteLine($"item 3: {a6.Id}");
Console.ReadKey();