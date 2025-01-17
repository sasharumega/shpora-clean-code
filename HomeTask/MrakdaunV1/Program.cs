using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using MrakdaunV1.Enums;
using MrakdaunV1.MrakdounEngine;


namespace MrakdaunV1
{
    public class Program
    {
        public static void Main()
        {
            var text = @"
# Курсив

Текст, _окруженный с двух сторон_ одинарными символами подчерка,
должен помещаться в HTML-тег &lt;em> вот так:

Текст, &lt;em>окруженный с двух сторон&lt;/em> одинарными символами подчерка,
должен помещаться в HTML-тег &lt;em>.



# Полужирный

__Выделенный двумя символами текст__ должен становиться полужирным с помощью тега &lt;strong>.



# Экранирование

Любой символ можно экранировать, чтобы он не считался частью разметки.
\_Вот это\_, не должно выделиться тегом &lt;em>.

Символ экранирования исчезает из результата, только если экранирует что-то.
Здесь сим\волы экранирования\ \должны остаться.\

Символ экранирования тоже можно экранировать: \\_вот это будет выделено тегом_ &lt;em>



# Взаимодействие тегов

Внутри __двойного выделения _одинарное_ тоже__ работает.

Но не наоборот — внутри _одинарного __двойное__ не_ работает.

Подчерки внутри текста c цифрами_12_3 не считаются выделением и должны оставаться символами подчерка.

Однако выделять часть слова они могут: и в _нач_але, и в сер_еди_не, и в кон_це._

В то же время выделение в ра_зных сл_овах не работает.

__Непарные_ символы в рамках одного абзаца не считаются выделением.

За подчерками, начинающими выделение, должен следовать непробельный символ. Иначе эти_ подчерки_ не считаются выделением 
и остаются просто символами подчерка.

Подчерки, заканчивающие выделение, должны следовать за непробельным символом. Иначе эти _подчерки _не считаются_ окончанием выделения 
и остаются просто символами подчерка.

В случае __пересечения _двойных__ и одинарных_ подчерков ни один из них не считается выделением.

Если внутри подчерков пустая строка ____, то они остаются символами подчерка.



# Заголовки

Абзац, начинающийся с ""# "", выделяется тегом &lt;h1> в заголовок.
В тексте заголовка могут присутствовать все прочие символы разметки с указанными правилами.

Таким образом

# Заголовок __с _разными_ символами__
превратится в:

&lt;h1>Заголовок &lt;strong>с &lt;em>разными&lt;/em> символами&lt;/strong>&lt;/h1>";
            
            var engine = new MrakdaunEngine();
            Console.WriteLine(engine.GetCharStatesString(engine.GetParsedTextStates(text)));
            File.WriteAllText("a.html", engine.GetParsedText(text));
        }
    }
}