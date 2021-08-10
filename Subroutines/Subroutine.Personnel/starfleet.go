package starfleet

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
)

type Officer struct {
	SerialNo   string `json:"SerialNo"`
	FirstName  string `json:"FirstName"`
	MiddleName string `json:"MiddleName"`
	LastName   string `json:"LastName"`
	Assignment string `json:"Assignment"`
	Station    string `json:"Station"`
}

//TNG
var TheNextGeneration []Officer = []Officer{
	{FirstName: "Jean-Luc", LastName: "Picard", SerialNo: "SP-937-215"},
	{FirstName: "William", MiddleName: "Thomas", LastName: "Riker", SerialNo: "SC-231-427"},
	{FirstName: "Data", SerialNo: "SC-231-427"},
	{FirstName: "Deanna", LastName: "Troi", SerialNo: "SC-231-427"},
	{FirstName: "Beverly", LastName: "Crusher", SerialNo: "SC-231-427"},
	{FirstName: "Geordi", LastName: "LaForge", SerialNo: "SC-231-427"},
}

func homePage(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Welcome to the Starfleet Personnel manifest")
}

func getTheNextGeneration(w http.ResponseWriter, r *http.Request) {
	json.NewEncoder(w).Encode(TheNextGeneration)
}

func generateSerialNo() {
	// var prefixes = []string{"SP", "SQ", "JL", "AR", "KI", "SK", "GH"}
	// prefix := prefixes[rand.Intn(len(prefixes))]
	// return prefix
}

func handleRequests() {
	http.HandleFunc("/", homePage)
	http.HandleFunc("/enterprise/d", getTheNextGeneration)
	log.Fatal(http.ListenAndServe(":5050", nil))
}

func main() {
	handleRequests()
}
