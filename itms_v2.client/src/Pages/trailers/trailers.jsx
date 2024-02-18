/* eslint-disable react/jsx-key */
import { useState, useEffect } from "react";
import {
  GridRowModes,
  DataGrid,
  GridToolbarContainer,
  GridActionsCellItem,
  GridRowEditStopReasons,
  GridToolbarQuickFilter,
} from "@mui/x-data-grid";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import SaveIcon from "@mui/icons-material/Save";
import CancelIcon from "@mui/icons-material/Close";
import { newTrailer, editTrailer,getTrailers } from "../../controllers/trailersController";
import Grid from "@mui/material/Unstable_Grid2"; // Grid version 2

function EditToolbar(props) {
  // eslint-disable-next-line react/prop-types
  const { setTrailers, setRowModesModel, Trailers } = props;
  const handleClick = () => {
    // eslint-disable-next-line react/prop-types
    const id = Trailers.length + 1;
    setTrailers((oldRows) => [
      ...oldRows,
      {
        id,
        Plate: "",
        standalone: false,
        adr: false,
        traffic: false,
        owner: "",
        active: true,
        isNew: true,
      },
    ]);
    setRowModesModel((oldModel) => ({
      ...oldModel,
      [id]: { mode: GridRowModes.Edit, fieldToFocus: "plate" },
    }));
  };
  return (
    <Grid container spacing={2}>
      <Grid xs={8} md={8}>
        <GridToolbarContainer>
          <Button color="primary" startIcon={<AddIcon />} onClick={handleClick}>
            Új pótkocsi
          </Button>
        </GridToolbarContainer>
      </Grid>
      <Grid xs={4} md={4}>
        <GridToolbarQuickFilter />
      </Grid>
    </Grid>
  );
}

const Trailers = () => {
  const [Trailers, setTrailers] = useState([]);
  const [Error, setError] = useState(false);
  const [rowModesModel, setRowModesModel] = useState({});

  useEffect(() => {
    getTrailers()
      .then((data) => {
        if (data.success) setTrailers(data.data);
        else setError(true);
      })
      .catch((error) => {
        console.error(error);
        setError(true);
      });
  }, []);

  const handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.rowFocusOut) {
      event.defaultMuiPrevented = true;
    }
  };

  const handleEditClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.Edit } });
  };

  const handleSaveClick = (id) => () => {
    setRowModesModel({ ...rowModesModel, [id]: { mode: GridRowModes.View } });
  };
  const handleCancelClick = (id) => () => {
    setRowModesModel({
      ...rowModesModel,
      [id]: { mode: GridRowModes.View, ignoreModifications: true },
    });

    const editedRow = Trailers.find((row) => row.id === id);
    if (editedRow.isNew) {
      setTrailers(Trailers.filter((row) => row.id !== id));
    }
  };

  const processRowUpdate = (newRow) => {
    if (newRow.isNew) {
      newTrailer(newRow).then((data) => {
        setTrailers(data.data);
      });
    } else {
      editTrailer(newRow).then((data) => {
        setTrailers(data.data);
      });
    }
    const updatedRow = { ...newRow, isNew: false };
    return updatedRow;
  };

  const handleRowModesModelChange = (newRowModesModel) => {
    setRowModesModel(newRowModesModel);
  };

  const onProcessRowUpdateError = (e) => {
    console.log(e);
  };
  const columns = [
    { field: "id", headerName: "ID", width: 75, editable: false },
    { field: "plate", headerName: "Rendszám", width: 100, editable: true },
    {
      field: "adr",
      headerName: "ADR",
      width: 75,
      editable: true,
      type: "boolean",
    },
    {
      field: "traffic",
      headerName: "Közút",
      width: 75,
      editable: true,
      type: "boolean",
    },
    {
      field: "standby",
      headerName: "Standby",
      width: 75,
      editable: true,
      type: "boolean",
    },
    {
      field: "active",
      headerName: "Aktív",
      width: 75,
      editable: true,
      type: "boolean",
    },
    { field: "owner", headerName: "Tulajdonos", width: 150, editable: true },
    {
      field: "loaded",
      headerName: "Rakott",
      width: 75,
      editable: true,
      type: "boolean",
    },
    {
      field: "goods",
      headerName: "Termék",
      width: 150,
      editable: true,
      type: "string",
    },

    {
      field: "parkigLocation",
      headerName: "Parkol",
      width: 150,
      editable: true,
      type: "string",
    },
    {
      field: "actions",
      type: "actions",
      headerName: "Műveletek",
      width: 100,
      cellClassName: "actions",
      getActions: ({ id }) => {
        const isInEditMode = rowModesModel[id]?.mode === GridRowModes.Edit;
        if (isInEditMode) {
          return [
            <GridActionsCellItem
              icon={<SaveIcon />}
              label="Save"
              sx={{
                color: "primary.main",
              }}
              onClick={handleSaveClick(id)}
            />,
            <GridActionsCellItem
              icon={<CancelIcon />}
              label="Cancel"
              className="textPrimary"
              onClick={handleCancelClick(id)}
              color="inherit"
            />,
          ];
        }

        return [
          <GridActionsCellItem
            icon={<EditIcon />}
            label="Edit"
            className="textPrimary"
            onClick={handleEditClick(id)}
            color="inherit"
          />,
        ];
      },
    },
  ];
  return (
    <>
      {Error ? (
        <h1>Hiba!</h1>
      ) : (
        <>
          <Box
            sx={{
              height: 700,
              width: "100%",
              "& .actions": {
                color: "text.secondary",
              },
              "& .textPrimary": {
                color: "text.primary",
              },
            }}
          >
            <DataGrid
              rows={Trailers}
              columns={columns}
              editMode="row"
              rowModesModel={rowModesModel}
              onRowModesModelChange={handleRowModesModelChange}
              onRowEditStop={handleRowEditStop}
              processRowUpdate={processRowUpdate}
              onProcessRowUpdateError={onProcessRowUpdateError}
              slots={{
                toolbar: EditToolbar,
              }}
              slotProps={{
                toolbar: {
                  setTrailers,
                  setRowModesModel,
                  Trailers,
                  showQuickFilter: true,
                },
              }}
            />
          </Box>
        </>
      )}
    </>
  );
};
export default Trailers;
