## Реализуйте кэш хранения объектов одного типа ##
В кэше могут храниться объекты одного типа, реализующего интерфейс `IDisposable`. Каждый объект имеет временную метку, когда к нему было последнее обращение. Также объекты в кэше могут обращаться к неуправляемым ресурсам, поэтому нужно гарантировать их освобождение.
Если к объекту не было обращений дольше, чем задано (можно задавать параметром при создании кэша), то объект уничтожается.
В кэше можно задавать максимальный размер. Когда поступает запрос на добавление нового элемента в кэш, но места больше нет (достигнут максимальный размер кэша – т.е. уже содержится максимальное количество элементов), то кэш запускает очистку – уничтожаются все «старые» объекты.
Предложите реализацию кэша и класса объектов, которые в нем хранятся.