import axios from 'axios';
import { useEffect, useMemo, useState } from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';


function FeatureFlagGrid() {
    const [rowData, setRowData] = useState([

    ]);
   
    const [columnDefs, setColumnDefs] = useState([
      {field: "projectFeatureFlagId", hide: true},
      {field: "flagName", sortable: true, filter:true},
      {field: "taskNumber", sortable: true, filter:true, headerName:"Project/Card or Ticket Number"},
      {field:"prLinks", headerName:"Peer Review Links"},
      {field: "workedOnBy",  headerName: "Developer Name"},
      {field:"isUiChanged"},
      {field: "isApiChanged"},
      {field: "isFredChanged"},
      {field: "isIvanChanged"},
      {field: "otherChangedApps"},
      {field: "dateCreated"},
    ])
     
    const defaultColDef = useMemo(()=>({
      sortable: true,
      filter:true
    }), []);
    
  
    useEffect(()=> {    
        getFeatureFlagData()
    }, [])

    const getFeatureFlagData = () =>{
        axios.get('http://localhost:5000/api/ProjectFlags')
        .then(response => {
          setRowData(response.data)
        })
    }
  
    const cellClickedListener = ((e: any) => {
      console.log('cellClicked', e.data);
    });  

  return (
    <div className='ag-theme-alpine' style={{height:500}}>      
        <AgGridReact 
          columnDefs={columnDefs}     
          rowData={rowData}
          defaultColDef={defaultColDef}
          rowSelection='single'
          animateRows = {true}
          onCellClicked={cellClickedListener}
        />
   </div>
  )
}

export default FeatureFlagGrid