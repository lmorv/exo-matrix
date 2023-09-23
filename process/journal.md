## 2023-09-23 - Can't say no to Coleoptera

Near the beginning of this fall semester, a friend, Fime de la Fuente contacted me with an idea for a serious game, based on some research he'd been working on with other people (paper included in the references folder in this repo). This was our conversation on Instagram: 

>Fime: 
>Hola Leo! ¿como estas?
>Oyes, yo sé que tu literalmente de dedicas a hacer juegos.
>Estoy haciendo una pasantía de investigación con una investigadora y se desarrolló un modelo de agentes (con reglas muy básicas) para unos coleopteros en una matriz agroecológica.
>Ahora queremos hacerlo un juego serio como para divulgación, pero ando mega perdido en tema como pasarlo a ser un juego.
>¿Tienes oportunidad de echarle una platicada, rolarme tips y obvio (si quieres) puedes ser parte de la construcción del juego y obviamente tendría tu autoría?
>puede ser también una ayudada nomás de una manera fácil tanto de pensar en el juego como de diseñarlo

>Leo: 
>Wow!
>Eso suena increible. Tengo muchas preguntas haha
>Son escarabajos no?
>me encantan los escarabajos
>Me encantaria saber mas hacerca del comportamiento de los agentes (como que tipo de movimiento pueden hacer, en que estados pueden estar, ) y supongo que la matriz se refiere como al efecto que tienen en su medio ambiente (?), como estas pensado en la representacion grafica de ese efecto?
>Y el estylo visual puede ser importante, como si te lo imaginas en 3d o 2d. lAs mates graficas van a ser diferentes e influiria un buen en las heramientas que escojes para construir la simulacion :p
>puedes utilizar un motor grafico como Unity o Unreal, o algo mucho mas basico como P5js en el browser.

> Fime: 
>que genial que te llame la atención :3 jejeje
>mira: te va todo el debraye
>(audio trascript)
>Que chido que te lata. Pues mira te voy a contar la historia; la historia es que en Oaxaca, en los valles centrales hay un lugar que se llama Zaachila. Es como un municipio. Este municipio tiene diferente 'calidad en la matriz', ahorita te digo que es 'calidad en la matriz' dependiendo de las practicas de agricultura llevadas a cabo, no? Cuando digo calidad en la matriz, ósea en biología como que se estudio --bueno no en biología; en ecología-- este que la conservación no es que importe tanto que un lugar este super conservado, sino que importa como que una meta población pueda como existir por todo el terreno como sin importar que este super conservado, no? Eso es una manera fácil de decirlo, por ejemplo como, pues no se, como las milpas no? son un habitat super importante para algunas especies de aves que las usan como pues pues de de ecosistema no? entonces se llevo a cabo como este concepto de agroecosistema. Y habemos personas que hacemos agroecología que pensamos que pues la agricultura tradicional es una manera muy chida de, pues de conservar tradiciones, cultura... pero también diversidad biológica no? esa es como la base de todo.
>Entonces partiendo de ese punto, ehhm, hicimos esta, este modelo de agentes en el cual como que, pues se estudio que los coleópteros --los curculiónidos-- que son escarabajos, como gorgojos as de cuenta son un super buen indicador porque están en la agricultura tradicional y casi nunca están en agricultura industrial no? osea son como un buen indicador. Y entonces una compa hiso un modelo, y modeló pues como alrededor de unas cuantas variables y como cambios de usos de suelo, este, que tan bueno es el parche --el parche es como el lugar-- como se va moviendo; si crese, si se reproduce, si sobrevive, si muere y asi. Y entonces es como una manera de entender como se comportan estas poblaciónes, como en torno a toda esta complejidad ecológica. 
>Si esta siendo como un poquito complicado, o al revez no si esta siendo muy baboso me avisas. Pero es que, eso, quiero comunicártelo chido. Ehhhm, y bueno total, pues lo que teníamos pensado era como usar este modelo --ósea traducirlo como a un jueguito. Y hacer un un este pues un juego, un juego serio como para divulgar, este, para que la gente lo juegue y aprenda no? como, pues como de estas interacciones, de como funcionan y así. De lo de el diseño, la verdad es que pues no tiene que ser un diseño super complejo. Yo creo que 2d esta super bien y así no? Y ósea 
>(end of audio transcript)

>Leo 
>Wowowo! Suena muy chido, y con muchas oportunidades en el diseño de interacciones. 
>Me imagino que el objeto de juego principal sería este 'parche' y como sus atributos y propiedades evolucionan en función a las variables con las que el jugador puede intervenir.
>Cuanto tiempo tienen para entregar el proyecto?

>Fime:
>si! justo como el municipio jaja, o puede ser nomás un parchecito
>pues en realidad creo que me latería ya entregarlo (el juego) ya acabado maximo febrero
>tener un draft para fin de mes, o algo así
>mira, mas o menos así se ve el modelo
>![[modelo.png]]
>mira, para que te des una idea
>...
>jajajaja

>Leo:
>whoa lol

>Fime:
>si….
>jajajajaja
>que terror
>pero nada, si quieres mañana te mando un mail con ideas/las reglas principales del modelo

>Leo:
>sas :))

>Fime:
>:^)

>Leo:
>tambien: La timeline del projecto suena factible, pero si creo que me voy a sentir super saturado si me comprometo a entrarle de lleno al 100% del desarrollo. Estoy justo empezando classes y tengo un projecto de investigacion (otro juego jaja) que estoy intentando terminar este semestre.

>Fime:
>Si obvio! Tu tranqui :)))

>Leo:
>Pero si me gusta mucho la idea y me encantaría darle a la conceptualización y lo que pueda <3

>Fime:
>Cualquier tip es super bien recibido! Y topo la saturación jajaja
>Y obvio siempre serás mencionado :^)
>Eso lo digo pa que lo sepas
>Y no tengas dudas jajaja

>Leo:
>Tambien siento que esta super alineado con otros objetivos de mi practica y de comunidad creativa y asi <3

>Fime:
>ggggenial

A couple of days later:

>Leo:
>Fime! Eh estado pensando un buen en el juego. Y me me vienen a la mente 2 juegps que tienen estilos similares y masomenos están el la misma area temática de lo que estamos intentando hacer:

>In Other Waters: https://store.steampowered.com/app/890720/In_Other_Waters/
>Life on the edge: https://store.steampowered.com/app/1968040/Life_on_the_Edge/

>Me imagino el gameplay un poco mas como un city-builder/ resource-management. Pero me gusta la idea de un punto de vista completamente top-down y un estilo visual como typo UI
>Creo que necesito un mas contexto de los métodos de investigación y teoría detrás de la practica. De los modelos de agentes y evaluación de matrices agro-ecologicas. Y especificamente como los agentes y las variables interactuan ebtre si.
>Me encantaria leer algunos papeles academicos y tratar de enter otros estudios similares, o cualquier cose que tengas en modelo actual.
>Y tambien queria preguntarte si puedo utilizar este proyecto para una clase de creación de investigación, y potencialmente como un caso de estudio para otra investigacion de metodos de documentacion del proceso creativo. Obvio creditos para todas las personas involucradas <3

>Fime:
>holisss leo
>me pasas tu whats o algo?
>jeje, siempre en instagram veo poco los mensajes
>y esto lo platicamos! yo creo que totalmente si (reply to "Y tambien queria preguntarte si puedo utilizar este proyecto para una clase de creación de investigación, y potencialmente...")
>pero woa charlarlo
>si quieres mándame un whatsapp/telegram y lo platicamos todo

And later on WhatsApp:

>Fime:
>oye, voy a hablar con Mariana, yo creo que es altamente probable que si se arme la colaboracion :))

The conversation continued with some logistics to meet on zoom later on and some major troubleshooting to view the model on a data visualization software called NetLogo. The model turned out to be way to large and computationally expensive to be navigable, but at least I got to look at the variables in context and get an idea of how it works on a very superficial level.

During the time of these conversations taking place and our zoom meeting my main narrative design insight was the idea of having two separate modes for interfacing with the game and the simulation: a human and a beetle mode. More on what that means design-wise later. And Fime and I agreed that the cultural/human aspect of the data should be a central focus of the experience.
I think the variable system design and the interaction design on top of that are gonna be the crux of iteration throughout the project. And I am really exited to see what it becomes!!