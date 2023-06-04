namespace domain

open domain.models

module abstractions =
    type IBreadRepository =
        abstract member Insert : bread: Bread -> unit
