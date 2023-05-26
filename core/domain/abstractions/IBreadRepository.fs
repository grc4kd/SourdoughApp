namespace domain

open models

module abstractions =
    type IBreadRepository =
        abstract member Insert : bread: Bread -> unit
