package main

import (
	"encoding/json"
	"fmt"
	"net/http"
)

type Post struct {
	Anot int `json:"Anot"`
}

func main() {
	// handle route using handler function
	http.HandleFunc("/", indexPage)
	http.HandleFunc("/posts", postHandler)
	http.ListenAndServe(":5051", nil)
}

func indexPage(w http.ResponseWriter, r *http.Request) {
	fmt.Fprint(w, "Fourier Analysis")
}

func postHandler(w http.ResponseWriter, r *http.Request) {
	posts := []Post{
		Post{Anot: 34},
		Post{Anot: 16},
	}

	json.NewEncoder(w).Encode(posts)
}
