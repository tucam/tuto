package e4geotools.parts;

import javax.annotation.PostConstruct;
import javax.inject.Inject;

import org.eclipse.e4.core.di.annotations.Optional;
import org.eclipse.e4.ui.di.Focus;
import org.eclipse.e4.ui.di.UIEventTopic;
import org.eclipse.e4.ui.model.application.ui.basic.MPart;
import org.eclipse.swt.SWT;
import org.eclipse.swt.widgets.Composite;
import org.geotools.map.MapContent;
import org.geotools.referencing.crs.DefaultGeographicCRS;
import org.geotools.renderer.lite.StreamingRenderer;
import org.geotools.swt.SwtMapPane;
import org.geotools.swt.action.OpenShapefileAction;
import org.geotools.swt.tool.PanTool;
import org.geotools.swt.tool.ZoomInTool;
import org.geotools.swt.tool.ZoomOutTool;
import org.osgi.service.event.Event;

public class SamplePart {
	private MPart part;
	private SwtMapPane mapPane;

	@PostConstruct
	public void createComposite(Composite parent, MPart part) {
		this.part = part;
		
		// create map content
		MapContent mapContent = new MapContent();
		mapContent.getViewport().setCoordinateReferenceSystem(DefaultGeographicCRS.WGS84);

		// create map view
		mapPane = new SwtMapPane(parent, SWT.BORDER | SWT.NO_BACKGROUND);
		mapPane.setMapContent(mapContent);

		// set the renderer
		StreamingRenderer renderer = new StreamingRenderer();
		mapPane.setRenderer(renderer);

	}

	@Focus
	public void setFocus() {
		mapPane.setFocus();
	}

	@Optional
	@Inject
	public void addShpFileToMap(@UIEventTopic("e4geotools/addShpFileEventTopic") Event evt) {
		OpenShapefileAction openAction = new OpenShapefileAction();
		openAction.setMapPane(mapPane);
		openAction.run();
	}
	
	@Optional
	@Inject
	public void zoomIn(@UIEventTopic("e4geotools/zoomInMapEventTopic") MPart part) {
		if (!this.part.equals(part))
			return;
		
		mapPane.setCursorTool(new ZoomInTool());
	}
	
	@Optional
	@Inject
	public void zoomOut(@UIEventTopic("e4geotools/zoomOutMapEventTopic") MPart part) {
		if (!this.part.equals(part))
			return;
		
		mapPane.setCursorTool(new ZoomOutTool());
	}
	
	@Optional
	@Inject
	public void pan(@UIEventTopic("e4geotools/panMapEventTopic") MPart part) {
		if (!this.part.equals(part))
			return;
		
		mapPane.setCursorTool(new PanTool());
	}
}