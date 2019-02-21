<?php
// process client request (via URL)
	header ("Content-Type_application/json");
	$funzione=$_GET['funzione'];
	switch($funzione)
	{
		case '0':
			$dati=datiConversione('libri.json');
			$arr=array();
			
			$i=0;
			//var_dump($dati);
			
			foreach ($dati['libro'] as $book)
			{
				
				$arr[$i] =$book['titolo'];
				$i=$i+1;
			}
		break;
		case '1'		
			$dati = datiConversione('../FileJSON/Libri.json');
			$reparti = datiConversione('../FileJSON/Reparti.json');
			$arr = array();
			$i = 0;
		
			foreach($dati['reparto'] as $reparto)
			{
				if(strtoupper($reparto['tipo']) == strtoupper('Fumetti'))
					$idFumetti=reparto['id'];
			}

		
			foreach($dati['libro'] as $book)
			{
				if($book['reparto'] == $idFumetti && strtoupper($book['categoria']) == strtoupper('I più venduti'))
				{
					$arr[$i] = $book['titolo'];
					$i = $i + 1;
				}
			}
		
			deliver_response(200,"fumetti", $arr);		
			
		break;
		case '2':
			
		break;
		case '3':
			
		break;
	}
	

	function deliver_response($status, $status_message, $data)
	{
		header("HTTP/1.1 $status $status_message");
		
		$response ['status']=$status;
		$response['status_message']=$status_message;
		$response['data']=$data;
		
		$json_response=json_encode($response);
		echo $json_response;
	}
	function datiConversione($json)
	{
		$str = file_get_contents($json);
		$dati = json_decode($str, true); 

		return $dati;
	}
	function get_price($find)
	{
		$books=datiConversione('libri.json');
		 foreach($books['book'] as $book)
		 {
			 if($book['name']==$find)
			 {
				 return $book['price'];
				 break;
			 }
		 }
    }

?>