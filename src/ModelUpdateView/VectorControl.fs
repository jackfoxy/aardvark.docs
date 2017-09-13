﻿module VectorControl

open Aardvark.Base             // math stuff such as V3d, Trafo3d
open Aardvark.UI            // the base infrastructure for elm style aardvark applications

open VectorControl

type Action = 
    | SetX of NumericControl.Action
    | SetY of NumericControl.Action
    | SetZ of NumericControl.Action

// call update logic of indiviual numeric controls
let update (m : VectorModel) (a : Action) =
    match a with
        | SetX a -> { m with x = NumericControl.update m.x a }
        | SetY a -> { m with y = NumericControl.update m.y a }
        | SetZ a -> { m with z = NumericControl.update m.z a }

let view (m : MVectorModel) =
    require Html.semui ( 
        body [] (        
            [
                div [] [text "numeric control x"]
                div [] [text "numeric control y"]
                div [] [text "numeric control z"]
            ]
        )
    )

let app =
    {
        unpersist = Unpersist.instance
        threads = fun _ -> ThreadPool.empty
        initial = VectorModel.initial
        update = update
        view = view
    }

let start() = App.start app





