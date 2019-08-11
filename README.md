This is the implementation of SPARD programming language.

SPARD language is briefly described in repo Wiki: https://github.com/VladimirKhil/Spard/wiki

The purpose of SPARD language is the transformation of objects sequences, primarily texts to texts. The language provides syntax capable of simple text transformations without excessive coding.

Current SPARD implementation is done in C# language. It is built as a .NET Standard 2.0 library. SPARD interpreter is a .NET Core 2.2 console application.

You need Microsoft Visual Studio 2017 or higher to compile the source code.

Projects description:

* *src\Spard*: main SPARD implementation
* *src\Spard.Executor*: SPARD interpreter as a command-line app
* *test\Spard.Test*: SPARD implementation test which also provides a set of helpful SPARD examples

You can test working SPARD examples and language interpreter here: http://vladimirkhil.com/lingware/spard/implementation?culture=en-US
